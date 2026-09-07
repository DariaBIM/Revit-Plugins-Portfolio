using System.ComponentModel;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace RevitAPI_FamilyRenamerV02.R22.Models
{
    public class FamilyRenameRow : INotifyPropertyChanged
    {
        private bool _isSelected = true;
        private ElementId _familyId;
        private string _familyName;
        private string _categoryName;
        private int _countInModel;
        private string _newFamilyName = string.Empty;
        private string _status = string.Empty;
        private Family _familyReference;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { if (_isSelected != value) { _isSelected = value; OnPropertyChanged(); } }
        }

        public ElementId FamilyId
        {
            get { return _familyId; }
            set { if (_familyId != value) { _familyId = value; OnPropertyChanged(); } }
        }

        public string FamilyName
        {
            get { return _familyName; }
            set { if (_familyName != value) { _familyName = value; OnPropertyChanged(); } }
        }

        public string CategoryName
        {
            get { return _categoryName; }
            set { if (_categoryName != value) { _categoryName = value; OnPropertyChanged(); } }
        }

        public int CountInModel
        {
            get { return _countInModel; }
            set { if (_countInModel != value) { _countInModel = value; OnPropertyChanged(); } }
        }

        public string NewFamilyName
        {
            get { return _newFamilyName; }
            set { if (_newFamilyName != value) { _newFamilyName = value; OnPropertyChanged(); } }
        }

        public string Status
        {
            get { return _status; }
            set { if (_status != value) { _status = value; OnPropertyChanged(); } }
        }

        public Family FamilyReference
        {
            get { return _familyReference; }
            set { if (_familyReference != value) { _familyReference = value; OnPropertyChanged(); } }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
