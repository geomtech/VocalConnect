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
            // Créer un objet SpeechRecognitionEngine
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("fr-FR"));

            recognizer.SetInputToDefaultAudioDevice();

            // Ajouter une grammaire de reconnaissance
            Choices commands = new Choices(new string[] { "Bonjour", "Aurevoir", "Il est quelle heure", "Salle du royaume", "Réunion", "la salle", "RPP", "prédication", "week-end", "réunion de pascal", "réunion alexy", "groupe" });
            GrammarBuilder grammarBuilder = new GrammarBuilder(commands);
            Grammar grammar = new Grammar(grammarBuilder);

            recognizer.LoadGrammar(grammar);

            // Gérer l'événement de reconnaissance
            recognizer.SpeechRecognized += (sender, e) =>
            {
                try
                {
                    switch (e.Result.Text)
                    {
                        case "Salle du royaume":
                        case "la salle":
                        case "Réunion":
                            OpenZoomMeeting(Properties.Settings.Default.kHZoomID, Properties.Settings.Default.kHZoomCode);
                            break;
                        case "RPP":
                        case "prédication":
                        case "réunion pour la prédication":
                            OpenZoomMeeting(Properties.Settings.Default.ministryZoomID, Properties.Settings.Default.ministryZoomCode);
                            break;
                        case "week-end":
                        case "réunion de pascal":
                        case "réunion alexy":
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
            if (string.IsNullOrEmpty(meetingID) || string.IsNullOrEmpty(meetingCode))
            {
                MessageBox.Show("Les paramètres pour l'ID de la réunion ou le code sont manquants.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string zoomURLPath = meetingID + "?pwd=" + meetingCode;
            Process.Start("https://zoom.us/j/" + zoomURLPath);
        }
    }
}
