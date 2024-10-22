using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace THConfigUpdater.Client.Helpers
{
    public class CustomOperationsHelper
    {
        private CustomOperations _ops;

        public CustomOperationsHelper(string customOperations)
        {
            _ops = JsonSerializer.Deserialize<CustomOperations>(customOperations, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public void PerformBeforeOperations()
        {
            PerformOperations(_ops.Before);
        }

        public void PerformAfterOperations()
        {
            PerformOperations(_ops.After);
        }

        private void PerformOperations(CustomOperationsEntry entries)
        {
            if (entries == null)
            {
                return;
            }

            PerformChecks(entries.Checks);
            PerformCommands(entries.Commands);
        }

        private void PerformChecks(List<CheckOperation> checks)
        {
            foreach (var check in checks)
            {
                if (check.Type == "service")
                {
                    if (check.Condition == "exists")
                    {
                        if (!ServiceExists(check.Entity))
                        {
                            throw new Exception("Service does not exist: " + check.Entity);
                        }
                    }
                    else if (check.Condition == "not_exists")
                    {
                        if (ServiceExists(check.Entity))
                        {
                            throw new Exception("Service exists: " + check.Entity);
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid condition: " + check.Condition);
                    }
                }
            }
        }

        private void PerformCommands(List<CommandOperation> commands)
        {
            foreach (var command in commands)
            {
                if (command.Type == "service")
                {
                    if (command.Operation == "stop")
                    {
                        StopService(command.Entity);
                    }
                    else if (command.Operation == "start")
                    {
                        StartService(command.Entity);
                    }
                    else
                    {
                        throw new Exception("Invalid operation: " + command.Operation);
                    }
                }
            }
        }

        private bool ServiceExists(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            return services.Any(s => s.ServiceName == serviceName);
        }

        private void StopService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            if (service.Status != ServiceControllerStatus.Stopped)
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped);
            }
        }

        private void StartService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            if (service.Status != ServiceControllerStatus.Running)
            {
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running);
            }
        }
    }

    class CustomOperations
    {
        public CustomOperationsEntry Before { get; set; }
        public CustomOperationsEntry After { get; set; }
    }

    class CustomOperationsEntry
    {
        public List<CheckOperation> Checks { get; set; }
        public List<CommandOperation> Commands { get; set; }
    }

    class CheckOperation
    {
        public string Type { get; set; }
        public string Entity { get; set; }
        public string Condition { get; set; }
    }

    class CommandOperation
    {
        public string Type { get; set; }
        public string Entity { get; set; }
        public string Operation { get; set; }
    }
}
