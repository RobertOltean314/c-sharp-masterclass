using _04_Cookies_Recipe_Assigment.DataAccess;
using _04_Cookies_Recipe_Assigment.FileAccess;

try
{
    const FileFormat Format = FileFormat.Json;

    IStringsRespository stringsRepository = Format == FileFormat.Json
        ? new StringsJsonRespository()
        : new StringsTextualRespository();

    const string FileName = "recipes";
    var fileMetaData = new FileMetaData(FileName, Format);

    var ingredientsRegister = new IngredientsRegister();

    var cookiesRecipeApp = new CookiesRecipeApp(
        new RecipeReopository(stringsRepository, ingredientsRegister),
        new RecipeConsoleUserInteraction(ingredientsRegister));

    cookiesRecipeApp.Run(fileMetaData.toPath());
}
catch (Exception ex)
{
    Console.WriteLine("We're sorry, the application expected" +
        "an unexpected error and will be closed." +
        "The error message: " + ex.Message);
    Console.WriteLine("Press any key to close the application.");
    Console.ReadKey();
}
