using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using MvvmFoundation.Wpf;
using System.Windows.Media;

using Microsoft.Win32; // home of OpenFileDialog and SaveFileDialog
using System.Windows.Controls; // home of PrintDialog ...


namespace I4GUI
{
    // Just to reference it from xaml
    public class Agents : ObservableCollection<Agent>, INotifyPropertyChanged
    {

        public Agents()
        {
            Add(new Agent("001", "Nina", "Assassination", "UpperVolta"));
            Add(new Agent("007", "James Bond", "Martinis", "North Korea"));
        }
        #region AgentCommands
        ICommand _nyCommand;

        public ICommand NyCommand
        {
            get { return _nyCommand ?? (_nyCommand = new RelayCommand(AddAgent)); }
        }

        private void AddAgent()
        {
            Add(new Agent());
            NotifyPropertyChanged("Count");
            CurrentIndex = Count - 1;
        }

      ICommand _fremCommand;

        public ICommand FremCommand
        {
            get { return _fremCommand ?? (_fremCommand = new RelayCommand(FremAgent)); }
        }

        private void FremAgent()
        {
            if (CurrentIndex < Count - 1)
                ++CurrentIndex;
        }

         ICommand _tilbageCommand;

        public ICommand TilbageCommand
        {
            get { return _tilbageCommand ?? (_tilbageCommand = new RelayCommand(() => --CurrentIndex, () => CurrentIndex>0)); }
        }

      ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteAgent, DeleteAgentCanExecute)); }
        }

        private void DeleteAgent()
        {
            RemoveAt(CurrentIndex);
        }

        private bool DeleteAgentCanExecute()
        {
            if (Count > 0 && CurrentIndex >= 0)
                return true;
            else
                return false;


        }

        ICommand _CloseAppCommand;
        public ICommand CloseAppCommand
        {
            get { return _CloseAppCommand ?? (_CloseAppCommand = new RelayCommand(CloseCommand_Execute)); }
        }

        private void CloseCommand_Execute()
        {
            Application.Current.MainWindow.Close();

            // Could use the line below instead
            // Application.Current.Shutdown();
        }
        string filename = "";
       SaveFileDialog saveFileDialog = new SaveFileDialog();
         ICommand _saveAsFileCommand;

        public ICommand SaveAsFileCommand
        {
            get { return _saveAsFileCommand ?? (_saveAsFileCommand = new RelayCommand<string>(SaveAsFile)); }
        }

        private void SaveAsFile(string argFilename)
        {
            if (argFilename == "")
            {
                saveFileDialog.ShowDialog();
                //MessageBox.Show("You must enter a file name in the File Name textbox!", "Unable to save file",
                //    MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                filename = argFilename;
                SaveFile();
            }
        }

        ICommand _SaveFileCommand;

        public ICommand SaveFileCommand
        {
            get { return _SaveFileCommand ?? (_SaveFileCommand = new RelayCommand(SaveFile,SaveFileCanExecute)); }
        }

        private bool SaveFileCanExecute()
        {
            return (filename != "" && Count > 0);

        }

        private void SaveFile()
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Agents));
            TextWriter myTextWriter = new StreamWriter(filename);
            myXmlSerializer.Serialize(myTextWriter,this);
            myTextWriter.Close();
        }

        private ICommand _newFileCommand;

        public ICommand NewFileCommand
        {
            get { return _newFileCommand ?? (_newFileCommand = new RelayCommand(NewFile)); }
        }

        private void NewFile()
        {
            
            
        }

        #endregion

        #region StyleCommands

        ICommand _colorCommand;

       public ICommand ColorCommand
        {
            get { return _colorCommand ?? (_colorCommand = new RelayCommand<string>(ChangeColor)); }
        }

        private void ChangeColor(string color)
        {
            SolidColorBrush myBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Blue"));

            try
            {
                if(color != null)
                {
                    myBrush.Color = (Color)ColorConverter.ConvertFromString(color);
                }

            }
            catch(Exception)
            {
                MessageBox.Show("Default color is used");
                myBrush.Color = (Color)ColorConverter.ConvertFromString("Blue");
            }

            Application.Current.MainWindow.Resources["BackgroundColor"] = myBrush;
        }

        #endregion

        #region prop
        int currentIndex = -1;

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex != value)
                {
                    currentIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }



        

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
    #endregion


    #region agent
    [Serializable]
    public class Agent
    {
        string id;
        string codeName;
        string speciality;
        string assignment;

        public Agent()
        {
        }

        public Agent(string aId, string aName, string aSpeciality, string aAssignment)
        {
            id = aId;
            codeName = aName;
            speciality = aSpeciality;
            assignment = aAssignment;
        }

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string CodeName
        {
            get
            {
                return codeName;
            }
            set
            {
                codeName = value;
            }
        }

        public string Speciality
        {
            get
            {
                return speciality;
            }
            set
            {
                speciality = value;
            }
        }

        public string Assignment
        {
            get
            {
                return assignment;
            }
            set
            {
                assignment = value;
            }
        }
        #endregion
    }
}
