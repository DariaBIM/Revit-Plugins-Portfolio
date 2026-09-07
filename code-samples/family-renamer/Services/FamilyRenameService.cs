using System.Collections.Generic;
using Autodesk.Revit.DB;
using RevitAPI_FamilyRenamerV02.R22.Models;

namespace RevitAPI_FamilyRenamerV02.R22.Services
{
    public class FamilyRenameService
    {
        public int Rename(Document doc, IList<FamilyRenameRow> rows)
        {
            int renamedCount = 0;

            using (Transaction transaction = new Transaction(doc, "Rename Families"))
            {
                transaction.Start();

                foreach (FamilyRenameRow row in rows)
                {
                    if (!row.IsSelected || row.Status != "OK" || row.FamilyReference == null)
                    {
                        continue;
                    }

                    string trimmedNewName = row.NewFamilyName == null
                        ? string.Empty
                        : row.NewFamilyName.Trim();

                    row.FamilyReference.Name = trimmedNewName;
                    renamedCount++;
                }

                transaction.Commit();
            }

            return renamedCount;
        }
    }
}
