using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaWave.Models;
using ChromaWave.Controller;
using ChromaWave.Views;
using ChromaWave.Helpers;
using NAudio.Dsp;
using ChromaWave.Views.Forms.Visuals;
using ChromaWave.Views.Components.Visuals;

namespace ChromaWave
{
    public partial class FormMain : Form
    {
        private Settings pSettings;
        
        public FormMain()
        {
            InitializeComponent();
            Setup();
        }

        public void Setup()
        {
            timerUIUpdate.Interval = 1000 / 30; //Fps used to update the UI
            tabEffects.SetRenderCanvas(tabDevices.GetRenderCanvas()); //Set the RenderCanvas from Devices to Effects

            foreach (Control tab in panelRenderTab.Controls) //Call Setup for all tabs
                if (tab is Tab)
                    (tab as Tab).Setup();

            loadSettings();
            showTab(tabDevices); //Show default tab
        }

        #region Private
        public void loadSettings()
        {
            this.pSettings = SettingsController.Load();
            foreach (Control tab in panelRenderTab.Controls) //Call ApplySettings for all tabs
                if (tab is Tab)
                    (tab as Tab).ApplySettings(pSettings);
        }

        private void saveSettings()
        {
            foreach(Control tab in panelRenderTab.Controls)
                if(tab is Tab)
                    (tab as Tab).SaveSettings(pSettings);
            SettingsController.Save(pSettings);
        }

        private void showTab(Control tab)
        {
            if (panelRenderTab.Controls.IndexOf(tab) < 0)
                throw new Exception("Tab was not found in the tabControl");
            foreach (Control childTab in panelRenderTab.Controls)
            {
                if (childTab == tab)
                    childTab.BringToFront();
                //else
                //    childTab.Hide();
            }
        }

        private void TimerUIUpdate_Tick(object sender, EventArgs e)
        {
            this.SuspendLayout();
            foreach (Control tab in panelRenderTab.Controls)
                if (tab is Tab)
                    (tab as Tab).Update();
            //Re-draw controls
            this.ResumeLayout();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Control tab in panelRenderTab.Controls)
                if (tab is Tab)
                    (tab as Tab).Stop();
        }

        private void buttonMenuDevices_Click(object sender, EventArgs e)
        {
            showTab(tabDevices);
        }

        private void buttonMenuEffects_Click(object sender, EventArgs e)
        {
            showTab(tabEffects);
        }
        #endregion
    }
}
