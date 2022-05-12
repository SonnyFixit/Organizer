using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OrganizerApp.Models;

namespace OrganizerApp.ViewModels.Commands
{
    class NewNoteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public NotesViewModel NVM { get; set; }

        public NewNoteCommand(NotesViewModel nvm)
        {
            NVM = nvm;
        }


        public bool CanExecute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;

            if(selectedNotebook != null)
            {
                return true;
            }
            
            return false;
        }

        public void Execute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            NVM.CreateNote(selectedNotebook.ID);
            
        }
    }
}
