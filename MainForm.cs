using System;
using System.Diagnostics;
using System.Security.Policy;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace VocalConnect
{
    public partial class MainForm : Form
    {
        private bool wantZoom = false;
        private bool inZoom = false;
        private System.Media.SoundPlayer bienvenuePlayer = new System.Media.SoundPlayer(Properties.Resources.bienvenue);
        private System.Media.SoundPlayer errorPlayer = new System.Media.SoundPlayer(Properties.Resources.erreur);
        private System.Media.SoundPlayer unknownCommandPlayer = new System.Media.SoundPlayer(Properties.Resources.commande_non_reconnue);
        private System.Media.SoundPlayer closingPlayer = new System.Media.SoundPlayer(Properties.Resources.fermeture);
        private System.Media.SoundPlayer connectPlayer = new System.Media.SoundPlayer(Properties.Resources.connexion);
        private System.Media.SoundPlayer missingSettingsPlayer = new System.Media.SoundPlayer(Properties.Resources.parametres_manquants);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // start audio from ressources
            bienvenuePlayer.Play();

            timer1.Interval = 60000;
            timer1.Start();
            timer1.Tick += (s, ev) =>
            {
                if (wantZoom == false)
                {
                    bienvenuePlayer.Play();
                }
            };

            // Créer un objet SpeechRecognitionEngine
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("fr-FR"));

            recognizer.SetInputToDefaultAudioDevice();

            // Ajouter une grammaire de reconnaissance
            Choices commands = new Choices(new string[] { "Zoom", "Stop", "réunion", "prédication", "groupe" });
            GrammarBuilder grammarBuilder = new GrammarBuilder(commands);
            Grammar grammar = new Grammar(grammarBuilder);

            recognizer.LoadGrammar(grammar);

            // Gérer l'événement de reconnaissance
            recognizer.SpeechRecognized += (sender, e) =>
            {
                if (wantZoom == false)
                {
                    try
                    {
                        switch (e.Result.Text)
                        {
                            case "Zoom":
                                wantZoom = true;
                                connectPlayer.Play();
                                break;
                            case "Stop":
                                closingPlayer.Play();
                                Application.Exit();
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        errorPlayer.Play();
                    }
                } 
                else
                {
                    if (inZoom == false)
                    {
                        try
                        {
                            switch (e.Result.Text)
                            {
                                case "réunion":
                                    OpenZoomMeeting(Properties.Settings.Default.kHZoomID, Properties.Settings.Default.kHZoomCode);
                                    break;
                                case "prédication":
                                    OpenZoomMeeting(Properties.Settings.Default.ministryZoomID, Properties.Settings.Default.ministryZoomCode);
                                    break;
                                case "groupe":
                                    OpenZoomMeeting(Properties.Settings.Default.groupZoomID, Properties.Settings.Default.groupZoomCode);
                                    break;
                                case "Stop":
                                    closingPlayer.Play();
                                    Application.Exit();
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (Exception)
                        {
                            errorPlayer.Play();
                        }
                    }
                }
            };

            // Démarrer la reconnaissance
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        private void OpenZoomMeeting(string meetingID, string meetingCode)
        {
            inZoom = true;

            Properties.Settings.Default.Reload();

            if (string.IsNullOrEmpty(meetingID) || string.IsNullOrEmpty(meetingCode))
            {
                missingSettingsPlayer.Play();
                return;
            }

            string zoomURL = "zoommtg://zoom.us/join?action=join&confno=" + meetingID + "&pwd=" + meetingCode;

            Process.Start(new ProcessStartInfo
            {
                FileName = zoomURL,
                UseShellExecute = true
            });

            Application.Exit();
        }
    }
}
