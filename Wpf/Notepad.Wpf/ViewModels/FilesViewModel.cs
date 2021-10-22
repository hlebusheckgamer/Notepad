using Microsoft.VisualStudio.PlatformUI;
using Notepad.Wpf.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Notepad.Wpf.ViewModels
{
    public sealed class FilesViewModel : NotifyEntity
    {
        private int _counter = 2;

        public ObservableCollection<File> Files { get; }

        private File _selectedFile;
        public File SelectedFile
        {
            get => _selectedFile;
            set => SetValue(ref _selectedFile, value, nameof(SelectedFile));
        }

        public FilesViewModel()
            : this(null) { }
        public FilesViewModel(string filePath)
        {
            var file = filePath != null ? new File() { FullName = filePath } : new File("Новый файл");
            Files = new ObservableCollection<File>() { file };
            SelectedFile = file;
#if DEBUG
            Files.Add(new File("File 2"));
            Files.Add(new File("File 34"));
#endif
        }

        private ICommand _addNewFileCommand;
        public ICommand AddNewFileCommand => _addNewFileCommand ??= new DelegateCommand(AddNewFile);

        private void AddNewFile()
            =>Files.Add(new File($"Новый файл {_counter++}"));

        private void AddFile(File file)
            => Files.Add(file);

        private ICommand _saveSelectedFileCommand;
        public ICommand SaveSelectedFileCommand => _saveSelectedFileCommand ??= new DelegateCommand(SaveSelectedFile, () => SelectedFile?.IsSaved == false);

        private void SaveSelectedFile()
            => SaveFile(SelectedFile);

        private void SaveFile(File file)
        {
            file.IsSaved = true;
        }

    }
}
