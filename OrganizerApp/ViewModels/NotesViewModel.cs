using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

using OrganizerApp.Models;
using OrganizerApp.ViewModels.Commands;
using OrganizerApp.ViewModels.Helpers;

namespace OrganizerApp.ViewModels
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> Notebooks {get; set; }
        public ObservableCollection<Note> Notes { get; set; }

        private Notebook selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                //Everytime the value changes, it will rise the OnPropertyChanged, allowing to access corresponding notes
                

                selectedNotebook = value;
                OnPropertyChanged("SelectedNotebook");
                GetNotes();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

  

        public NewNotebookCommand NewNotebookCommand { get; set; }

        public NewNoteCommand NewNoteCommand { get; set; }

        public NotesViewModel()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            GetNotebooks();
        }

#region Creating Notes and Notebook methods

        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "New notebook"
            };

            DatabaseHelper.Insert(newNotebook);


            //Update list view with new notebooks
            GetNotebooks();
        }


        //Recieve int from Note id



        public void CreateNote (int notebookID)
        {
            Note newNote = new Note()
            {
                NotebookID = notebookID,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = $"Note for {DateTime.Now.ToString()}"


            };

            DatabaseHelper.Insert(newNote);


            //Update list view with new notes
            GetNotes();
        }

#endregion


#region Getting data from Notebooks and Notes methods
        private void GetNotebooks()
        {
            var notebooks = DatabaseHelper.Read<Notebook>();

            Notebooks.Clear();

            foreach (var notebook in notebooks)
            {
                Notebooks.Add(notebook);
            }
        }

        //Notes need to be filtered.
        //Only selected ones should be currenty displayed
        private void GetNotes()
        {
            //Var notes is of type Enumerable, so ToList can be used, to convert it to list.

            if (SelectedNotebook != null)
            {
                var notes = DatabaseHelper.Read<Note>().Where(n => n.NotebookID == SelectedNotebook.ID).ToList();

                Notes.Clear();

                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
            
        }

#endregion Getting data from Notebooks and Notes methods

        private void OnPropertyChanged (string propertyName)
        {
            //If property exists and has any subs, it will invoke the method and go along with the property change
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
