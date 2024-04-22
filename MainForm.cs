using System;
using System.Diagnostics;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace VocalConnect
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Cr�er un objet SpeechRecognitionEngine
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("fr-FR"));

            recognizer.SetInputToDefaultAudioDevice();

            // Ajouter une grammaire de reconnaissance
            Choices commands = new Choices(new string[] { "Bonjour", "Aurevoir", "Il est quelle heure", "Salle du royaume", "R�union", "la salle", "RPP", "pr�dication", "week-end", "r�union de pascal", "r�union alexy", "groupe" });
            GrammarBuilder grammarBuilder = new GrammarBuilder(commands);
            Grammar grammar = new Grammar(grammarBuilder);

            recognizer.LoadGrammar(grammar);

            // G�rer l'�v�nement de reconnaissance
            recognizer.SpeechRecognized += (sender, e) =>
            {
                try
                {
                    switch (e.Result.Text)
                    {
                        case "Salle du royaume":
                        case "la salle":
                        case "R�union":
                            OpenZoomMeeting(Properties.Settings.Default.kHZoomID, Properties.Settings.Default.kHZoomCode);
                            break;
                        case "RPP":
                        case "pr�dication":
                        case "r�union pour la pr�dication":
                            OpenZoomMeeting(Properties.Settings.Default.ministryZoomID, Properties.Settings.Default.ministryZoomCode);
                            break;
                        case "week-end":
                        case "r�union de pascal":
                        case "r�union alexy":
                        case "groupe":
                            OpenZoomMeeting(Properties.Settings.Default.groupZoomID, Properties.Settings.Default.groupZoomCode);
                            break;
                        default:
                            // Commande non reconnue
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // D�marrer la reconnaissance
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        private void OpenZoomMeeting(string meetingID, string meetingCode)
        {
            if (string.IsNullOrEmpty(meetingID) || string.IsNullOrEmpty(meetingCode))
            {
                MessageBox.Show("Les param�tres pour l'ID de la r�union ou le code sont manquants.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string zoomURLPath = meetingID + "?pwd=" + meetingCode;
            Process.Start("https://zoom.us/j/" + zoomURLPath);
        }
    }
}
