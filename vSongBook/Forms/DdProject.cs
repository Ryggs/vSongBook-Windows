﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Finisar.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace vSongBook
{
    public partial class DdProject : Form
    {
        bool isBold, hasChorus;
        string[] songtemps, songstanzas, versechorus, versecounts;
        string sqlQuery, songtext, fontxt;
        int fontsize = 0, stanzas = 0, cur_stz = 0, last_stz = 0, fontno = 1;
        AppDatabase appDB;
        SQLiteDataReader reader;
        private AppFunctions vsbf = new AppFunctions();
        private AppSettings settings = new AppSettings();
        
        public DdProject()
        {
            InitializeComponent();
            fontsize = settings.FontSizeProject;
            fontno = vsbf.fontNo(settings.FontTypeProject);
            fontxt = settings.FontTypeProject;
            isBold = settings.FontBoldProject;
        }
        
        private void DdProject_Load(object sender, EventArgs e)
        {
            fontManager();
            loadSingleSong(settings.CurrentSong);
            txtCommandLine.Focus();
        }

        private void fontManager()
        {
            try { lblSongTitle.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 5, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { lblSongLabel.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 3, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { lblSongno.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 3, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { lblItem.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 3, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { lblDetails.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 3, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { lblVerses.Font = new Font(settings.FontTypeGeneral, settings.FontSizeGeneral + 3, settings.FontBoldGeneral ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
            try { lblSongText.Font = new Font(fontxt, fontsize, isBold ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
            catch (Exception) { }
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            txtCommandLine.Select();
        }

        public void loadSingleSong(int songid)
        {
            try
            {
                string temptext = "", tempverse = "", tempcount = "";
                cur_stz = 0;
                sqlQuery = "SELECT *, books.title AS songbook FROM songs LEFT JOIN books ON songs.book = books.code WHERE songid=" + songid + ";";
                appDB = new AppDatabase();
                reader = appDB.getSingle(sqlQuery);
                while (reader.Read())
                {
                    lblSongno.Text = "#" + reader["number"].ToString();
                    lblSongTitle.Text = reader["number"].ToString() + "# " + vsbf.textRender(reader["title"].ToString()) + " " + reader["key"].ToString().Replace("-", "");
                    lblDetails.Text = reader["songbook"].ToString();
                    songtext = reader["content"].ToString();
                }
                appDB.sqlClose();
                
                if (Regex.Matches(songtext, "CHORUS").Count == 1)
                {
                    songtemps = songtext.Split('|');
                    int tempscount = songtemps.Length - 1;
                    string chorustr = songtemps[1].Replace("CHORUS$", "");
                    temptext = songtemps[0] + "#" + chorustr;
                    tempverse = "VERSE#CHORUS";
                    tempcount = "1 of " + tempscount + "# ";
                    for (int i = 2; i < tempscount + 1; i++)
                    {
                        temptext = temptext + "#" + songtemps[i] + "#" + chorustr;
                        tempverse = tempverse + "#VERSE#CHORUS";
                        tempcount = tempcount + "#" + i + " of " + tempscount + "# ";
                    }
                    songstanzas = temptext.Split('#');
                    hasChorus = true;
                }
                else
                {
                    songstanzas = songtext.Split('|');
                    tempverse = "VERSE";
                    tempcount = "1 of " + songstanzas.Length;
                    for (int i = 2; i < songstanzas.Length; i++)
                    {
                        tempverse = tempverse + "#VERSE";
                        tempcount = tempcount + "#" + (i - 1) + " of " + songstanzas.Length;
                    }
                    hasChorus = false;
                }

                versechorus = tempverse.Split('#');
                versecounts = tempcount.Split('#');
                stanzas = songstanzas.Length;

                pbxDown.Visible = true;

                lblSongText.Text = vsbf.songRender(songstanzas[cur_stz]);
                lblItem.Text = versechorus[cur_stz];
                lblVerses.Text = versecounts[cur_stz];
                //lblDetails.Text = stanzas.ToString();
            }
            catch (Exception ex)
            {
                lblSongTitle.Text = "Song projection failed";
                lblSongText.Text = "Oops! Song projection failed due to: " + ex.Message;
            }
        }
        private void previousStanza()
        {
            try
            {
                cur_stz = cur_stz - 1;
                lblSongText.Text = vsbf.songRender(songstanzas[cur_stz]);
                lblItem.Text = versechorus[cur_stz];
                lblVerses.Text = versecounts[cur_stz];
                if (cur_stz == 0) pbxUp.Visible = false;
                else pbxUp.Visible = true;
                if (cur_stz == (stanzas - 1)) pbxDown.Visible = false;
                else pbxDown.Visible = true;
                last_stz = cur_stz;
            }
            catch (Exception)
            {
                cur_stz = 0;
                lineTop.BackColor = Color.Red;
                tmrLinerr.Enabled = true;
            }
        }
        private void nextStanza()
        {
            try
            {
                cur_stz = cur_stz + 1;
                lblSongText.Text = vsbf.songRender(songstanzas[cur_stz]);
                lblItem.Text = versechorus[cur_stz];
                lblVerses.Text = versecounts[cur_stz];
                if (cur_stz == 0) pbxUp.Visible = false;
                else pbxUp.Visible = true;
                if (cur_stz == (stanzas - 1)) pbxDown.Visible = false;
                else pbxDown.Visible = true;
            }
            catch (Exception)
            {
                cur_stz = 0;
                lineDown.BackColor = Color.Red;
                tmrLinerr.Enabled = true;
            }
        }

        private void loadStanza(int stanzano)
        {
            try
            {
                cur_stz = stanzano;
                lblSongText.Text = vsbf.songRender(songstanzas[cur_stz]);
                lblItem.Text = versechorus[cur_stz];
                lblVerses.Text = versecounts[cur_stz];
                if (cur_stz == 0) pbxUp.Visible = false;
                else pbxUp.Visible = true;
                if (cur_stz == (stanzas - 1)) pbxDown.Visible = false;
                else pbxDown.Visible = true;
            }
            catch (Exception)
            {
                cur_stz = 0;
                lineTop.BackColor = Color.Red;
                lineDown.BackColor = Color.Red;
                tmrLinerr.Enabled = true;
            }
        }

        private void txtCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    previousStanza();
                    break;
                case Keys.Down:
                    nextStanza();
                    break;
                case Keys.Subtract:
                    if (fontsize >= 10)
                    {
                        try
                        {
                            fontsize = fontsize - 3;
                            settings.FontSizeProject = fontsize;
                            lblSongText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, settings.FontBoldProject ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.Add:
                    if (fontsize >= 50)
                    {
                        try
                        {
                            fontsize = fontsize + 3;
                            settings.FontSizeProject = fontsize;
                            lblSongText.Font = new Font(settings.FontTypeProject, settings.FontSizeProject, settings.FontBoldProject ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.Left:

                    break;

                case Keys.Right:

                    break;

                case Keys.Oemcomma:
                    if (fontsize >= 10)
                    {
                        try
                        {
                            fontsize = fontsize - 2;
                            settings.FontSizeProject = fontsize;
                            try { lblSongText.Font = new Font(fontxt, fontsize, settings.FontBoldProject ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                            catch (Exception) { }
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.OemPeriod:
                    if (fontsize <= 90)
                    {
                        try
                        {
                            fontsize = fontsize + 2;
                            settings.FontSizeProject = fontsize;
                            try { lblSongText.Font = new Font(fontxt, fontsize, settings.FontBoldProject ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                            catch (Exception) { }
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.Z:
                    if (fontno >= 0)
                    {
                        try
                        {
                            fontno = fontno - 1;
                            settings.FontTypeProject = vsbf.fonTxt(fontno);
                            try { lblSongText.Font = new Font(fontxt, fontsize, settings.FontBoldProject ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                            catch (Exception) { }
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.X:
                    if (fontno <= 11)
                    {
                        try
                        {
                            fontno = fontno + 1;
                            settings.FontTypeProject = vsbf.fonTxt(fontno);
                            try { lblSongText.Font = new Font(fontxt, fontsize, isBold ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                            catch (Exception) { }
                        }
                        catch (Exception) { }
                    }
                    break;

                case Keys.NumPad1:
                case Keys.D1:
                    loadStanza(0);
                    break;

                case Keys.NumPad2:
                case Keys.D2:
                    if (stanzas >= 2)
                    {
                        if (hasChorus) loadStanza(2);
                        else if (!hasChorus && stanzas > 2) loadStanza(1);
                    }
                    break;

                case Keys.NumPad3:
                case Keys.D3:
                    if (stanzas >= 4)
                    {
                        if (hasChorus) loadStanza(4);
                        else if (!hasChorus && stanzas > 3) loadStanza(2);
                    }
                    break;

                case Keys.NumPad4:
                case Keys.D4:
                    if (stanzas >= 6)
                    {
                        if (hasChorus) loadStanza(6);
                        else if (!hasChorus && stanzas > 4) loadStanza(3);
                    }
                    break;

                case Keys.NumPad5:
                case Keys.D5:
                    if (stanzas >= 8)
                    {
                        if (hasChorus) loadStanza(8);
                        else if (!hasChorus && stanzas > 5) loadStanza(4);
                    }
                    break;

                case Keys.NumPad6:
                case Keys.D6:
                    if (stanzas >= 10)
                    {
                        if (hasChorus) loadStanza(10);
                        else if (!hasChorus && stanzas > 6) loadStanza(5);
                    }
                    break;

                case Keys.NumPad7:
                case Keys.D7:
                    if (stanzas >= 12)
                    {
                        if (hasChorus) loadStanza(12);
                        else if (!hasChorus && stanzas > 7) loadStanza(6);
                    }
                    break;

                case Keys.NumPad8:
                case Keys.D8:
                    if (stanzas >= 14)
                    {
                        if (hasChorus) loadStanza(14);
                        else if (!hasChorus && stanzas > 8) loadStanza(7);
                    }
                    break;

                case Keys.NumPad9:
                case Keys.D9:
                    if (stanzas >= 16)
                    {
                        if (hasChorus) loadStanza(16);
                        else if (!hasChorus && stanzas > 9) loadStanza(8);
                    }
                    break;

                case Keys.C:
                    if (stanzas > 2 && hasChorus) loadStanza(1);
                    break;

                case Keys.Home:
                    loadStanza(0);
                    break;

                case Keys.End:
                    if (hasChorus) loadStanza(stanzas - 2);
                    else loadStanza(stanzas - 1);
                    break;

                case Keys.V:

                    break;

                case Keys.B:
                    try
                    {
                        if (isBold == true)
                        {
                            settings.FontBoldProject = false;
                            isBold = false;
                        }
                        else if (isBold == false)
                        {
                            settings.FontBoldProject = true;
                            isBold = true;
                        }
                        try { lblSongText.Font = new Font(fontxt, fontsize, isBold ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))); }
                        catch (Exception) { }
                    }
                    catch (Exception) { }
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }
      
        private void tblMain_Paint(object sender, PaintEventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lblSongLabel_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lblSongno_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void tblBottom_Paint(object sender, PaintEventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lblSongText_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lblVerse_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lblSongTitle_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void pbxUp_Click(object sender, EventArgs e)
        {
            previousStanza();
        }

        private void pbxDown_Click(object sender, EventArgs e)
        {
            nextStanza();
        }

        private void lineTop_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void lineDown_Click(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void grpMain_Enter(object sender, EventArgs e)
        {
            txtCommandLine.Focus();
        }

        private void tmrLinerr_Tick(object sender, EventArgs e)
        {
            lineTop.BackColor = Color.White;
            lineDown.BackColor = Color.White;
            tmrLinerr.Enabled = false;
        }

        private void lblSongText_Click_1(object sender, EventArgs e)
        {

        }


    }
}
