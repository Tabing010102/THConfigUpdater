using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THConfigUpdater.Client.Core.FileBased;
using THConfigUpdater.Client.Core.FileBased.Models;

namespace THConfigUpdater.Client.Forms
{
    public partial class TextProgressForm : Form
    {
        private FileBasedConfigService _fileBasedConfigService;

        public FileBasedConfig FileBasedConfig { get; set; }
        public List<ConfigFile> ConfigFiles { get; set; }

        public TextProgressForm(FileBasedConfigService fileBasedConfigService)
        {
            _fileBasedConfigService = fileBasedConfigService;

            InitializeComponent();
        }

        private void TextProgressForm_Load(object sender, EventArgs e)
        {

        }
    }
}
