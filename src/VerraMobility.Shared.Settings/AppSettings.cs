using VerraMobility.Shared.Settings.Models;

namespace VerraMobility.Shared.Settings;

/*Clase anemica o POCO que simplemente contiene las settings del host que se esta ejecutando*/
public class AppSettings
{
    public DatabaseSettings Database { get; set; } = null!;
    public AssemblySettings Assembly { get; set; } = null!;
    public ReaderTxtSettings ReaderTxt { get; set; } = null!;
}