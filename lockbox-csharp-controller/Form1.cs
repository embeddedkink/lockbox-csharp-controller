namespace lockbox_csharp_controller
{
    public partial class Form1 : Form
    {
        DeviceBrowser b = new DeviceBrowser();
        Controller c = new Controller();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            Task<List<Device>> GetDeviceTask = b.GetDevices();
            await GetDeviceTask;
            lbxDevices.Items.Clear();
            foreach (Device device in GetDeviceTask.Result)
            {
                lbxDevices.Items.Add(device);
            }
        }

        private async void btnInfo_Click(object sender, EventArgs e)
        {
            if (lbxDevices.SelectedItem != null)
            {
                Device d = lbxDevices.SelectedItem as Device;
                Task<String> t = c.GetInfoAsync(d.IP, d.Port);
                await t;
                String info = t.Result;
                MessageBox.Show(info);
            }
            else
            {
                MessageBox.Show("Select a box first!");
            }
        }

        private async void btnLock_Click(object sender, EventArgs e)
        {
            if (lbxDevices.SelectedItem != null)
            {
                Device d = lbxDevices.SelectedItem as Device;
                Task<String> t = c.LockAsync(d.IP, d.Port, tbxPassword.Text);
                await t;
                String info = t.Result;
                MessageBox.Show(info);
            }
            else
            {
                MessageBox.Show("Select a box first!");
            }
        }

        private async void btnUnlock_Click(object sender, EventArgs e)
        {
            if (lbxDevices.SelectedItem != null)
            {
                Device d = lbxDevices.SelectedItem as Device;
                Task<String> t = c.UnlockAsync(d.IP, d.Port, tbxPassword.Text);
                await t;
                String info = t.Result;
                MessageBox.Show(info);
            }
            else
            {
                MessageBox.Show("Select a box first!");
            }
        }
    }
}