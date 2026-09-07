using System;
using System.Collections.Generic;
using System.Linq;
using RevitAPI_FamilyRenamerV02.R22.Models;

namespace RevitAPI_FamilyRenamerV02.R22.Services
{
    public class FamilyRenameValidationService
    {
        private static readonly char[] InvalidCharacters =
        {
            '\\', '/', ':', ';', '?', '*', '<', '>', '|', '"', '[', ']', '{', '}'
        };

        public void Validate(IList<FamilyRenameRow> rows)
        {
            if (rows == null)
            {
                return;
            }

            HashSet<string> duplicateNewNames = GetDuplicateNewNames(rows);

            foreach (FamilyRenameRow row in rows)
            {
                if (!row.IsSelected)
                {
                    row.Status = "Not selected";
                    continue;
                }

                string trimmedNewName = row.NewFamilyName == null
                    ? string.Empty
                    : row.NewFamilyName.Trim();

                if (string.IsNullOrWhiteSpace(trimmedNewName))
                {
                    row.Status = "Empty new name";
                    continue;
                }

                string trimmedFamilyName = row.FamilyName == null
                    ? string.Empty
                    : row.FamilyName.Trim();

                if (string.Equals(trimmedNewName, trimmedFamilyName, StringComparison.OrdinalIgnoreCase))
                {
                    row.Status = "No change";
                    continue;
                }

                if (trimmedNewName.IndexOfAny(InvalidCharacters) >= 0)
                {
                    row.Status = "Invalid characters";
                    continue;
                }

                bool nameAlreadyExists = rows.Any(otherRow =>
                {
                    if (ReferenceEquals(otherRow, row))
                    {
                        return false;
                    }

                    string otherFamilyName = otherRow.FamilyName == null
                        ? string.Empty
                        : otherRow.FamilyName.Trim();

                    return string.Equals(
                        trimmedNewName,
                        otherFamilyName,
                        StringComparison.OrdinalIgnoreCase);
                });

                if (nameAlreadyExists)
                {
                    row.Status = "Name already exists";
                    continue;
                }

                if (duplicateNewNames.Contains(trimmedNewName))
                {
                    row.Status = "Duplicate new name";
                    continue;
                }

                row.Status = "OK";
            }
        }

        private static HashSet<string> GetDuplicateNewNames(IList<FamilyRenameRow> rows)
        {
            var nameCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (FamilyRenameRow row in rows)
            {
                if (!row.IsSelected || string.IsNullOrWhiteSpace(row.NewFamilyName))
                {
                    continue;
                }

                string trimmedName = row.NewFamilyName.Trim();
                int count;

                if (nameCounts.TryGetValue(trimmedName, out count))
                {
                    nameCounts[trimmedName] = count + 1;
                }
                else
                {
                    nameCounts[trimmedName] = 1;
                }
            }

            var duplicateNewNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (KeyValuePair<string, int> pair in nameCounts)
            {
                if (pair.Value > 1)
                {
                    duplicateNewNames.Add(pair.Key);
                }
            }

            return duplicateNewNames;
        }
    }
}
