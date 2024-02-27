using Bakery.ClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Mobile.Services;

public class MauiDbLocation : IDbLocation
{
    public string DbName { get => "Bakery.db"; }
    public string BaseDataDirecory { get => FileSystem.Current.AppDataDirectory; }
}
