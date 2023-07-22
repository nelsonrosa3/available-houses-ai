using Microsoft.SemanticKernel;

try
{
    var openAiApiKey = "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";
    var aiModel = "gpt-3.5-turbo-16k";
    var pluginsPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
    var contentPath = Path.Combine(Directory.GetCurrentDirectory(), "Content");
    
    var url =
        "https://www.clasificadosonline.com/UDREListing.asp?RESPueblos=%25&Category=%25&LowPrice=0&HighPrice=999999999&Bedrooms=%25&Area=&Repo=Repo&Opt=Opt&BtnSearchListing=Ver+Listado&redirecturl=%2Fudrelistingmap.asp&IncPrecio=1";
    
    var builder = new KernelBuilder();

    builder.WithOpenAIChatCompletionService(aiModel, openAiApiKey);

    var kernel = builder.Build();

    var orchestratorPlugin = kernel
        .ImportSemanticSkillFromDirectory(pluginsPath, "WebScrappingSkill");

    var context = kernel.CreateNewContext();

    context["househtml"] = File.ReadAllText(Path.Combine(contentPath,"clasificados-online-house-div.html"));
    // context["househtml"] = File.ReadAllText(Path.Combine(contentPath,"deshow-house-list.html"));
    
    var result = await orchestratorPlugin["House"].InvokeAsync(context);

    Console.WriteLine(result);
}
catch (Exception e)
{
    Console.WriteLine(e);
}


Console.ReadLine();