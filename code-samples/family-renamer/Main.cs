using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAPI_FamilyRenamerV02.R22.MainView;
using RevitAPI_FamilyRenamerV02.R22.ViewModels;
using System;

namespace RevitAPI_FamilyRenamerV02.R22
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                UIDocument uiDoc = commandData.Application.ActiveUIDocument;
                Document doc = uiDoc.Document;

                var viewModel = new MainViewViewModel(uiDoc, doc);
                var view = new MainView.MainView();
                view.DataContext = viewModel;
                view.ShowDialog();

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}
