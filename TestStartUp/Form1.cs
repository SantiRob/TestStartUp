
using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Windows.Forms;

namespace TestStartUp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text += Environment.UserName;
            VerificarYCrearAccesoDirecto();
        }

        private void VerificarYCrearAccesoDirecto()
        {
            string rutaAccesoDirecto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "TestStartUp - Acceso directo.lnk");

            if (System.IO.File.Exists(rutaAccesoDirecto))
            {
                label2.Text = "El acceso directo existe";
            }
            else
            {
                label2.Text = "El acceso directo no existe. Creando acceso directo...";

                // Ruta del archivo ejecutable de tu aplicación
                string rutaAplicacion = Application.ExecutablePath;

                // Crea el objeto WshShell
                var wshShell = new WshShell();

                // Crea el acceso directo
                IWshShortcut shortcut = (IWshShortcut)wshShell.CreateShortcut(rutaAccesoDirecto);
                shortcut.TargetPath = rutaAplicacion;
                shortcut.Save();

                label2.Text = "El acceso directo ha sido creado";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
