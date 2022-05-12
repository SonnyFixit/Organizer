using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OrganizerApp.Models;

namespace OrganizerApp.ViewModels.Commands
{
    public class NewNoteCommand : ICommand
    {

        public NotesViewModel NVM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        

       

        public NewNoteCommand(NotesViewModel nvm)
        {
            NVM = nvm;
        }


        public bool CanExecute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            return selectedNotebook != null ? true : false;
        }

        public void Execute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            NVM.CreateNote(selectedNotebook.ID);
            
        }
    }
}
