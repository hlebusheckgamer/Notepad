using System.Linq;

namespace Notepad.Wpf.Models
{
    public sealed class File : NotifyEntity
    {
        public File()
            : this(null) { }
        public File(string name)
            => Name = name;

        public string Name { get; private set; }

        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set => SetValue(ref _fullName, value, nameof(FullName), (fullName) => Name = fullName.Split(System.IO.Path.AltDirectorySeparatorChar).Last());
        }

        private bool _isSaved;
        public bool IsSaved
        {
            get => _isSaved;
            set => SetValue(ref _isSaved, value, nameof(IsSaved));
        }

        private string _content;
        public string Content
        {
            get => _content;
            set => SetValue(ref _content, value, nameof(Content), (content) => IsSaved = false);
        }

        private int _caretIndex;
        public int CaretIndex
        {
            get => _caretIndex;
            set => SetValue(ref _caretIndex, value, nameof(CaretIndex));
        }

        public override string ToString() => Name;
    }
}
