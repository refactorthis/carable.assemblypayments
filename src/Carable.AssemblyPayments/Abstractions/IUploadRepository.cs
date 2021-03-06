﻿using Carable.AssemblyPayments.Entities;
using System.Collections.Generic;

namespace Carable.AssemblyPayments.Abstractions
{
    public interface IUploadRepository
    {
        IList<Upload> ListUploads();

        Upload GetUploadById(string uploadId);

        Upload CreateUpload(string csvData);

        Upload GetStatus(string uploadId);

        Upload StartImport(string uploadId);
    }
}
