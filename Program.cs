using assignment.models;
using assignment.services;

namespace assignment;

class Program
{
    static async Task Main(string[] args)
    {
        await LoadFileContent(args[0]);
    
        Console.WriteLine("Menu:");
        Console.WriteLine("a. Print current state");
        Console.WriteLine("b. Change a value");
        string input = string.Empty;

        while(input != null && input != "exit") {
            input = Console.ReadLine();

            BaseActionService service = ActionServiceFactory.Create(input);
            service?.Preform(input);            
        }  
    }

    private static async Task LoadFileContent(string filePath)
    {
        try 
        {
            FileService fileService = new FileService();
            string fileContent = await fileService.ReadFile(filePath);
            if(fileContent == string.Empty) 
            {
                Console.WriteLine("No file content found");
                return;
            }

            Dictionary<int, StateEntity> state = fileService.ParseFileContent(fileContent);
            if(state == null || state.Count == 0)
            {
                Console.WriteLine("State is empty");
                return;
            }

            StateService stateService = StateService.GetInstance;
            stateService.State = state;
        }
        catch(Exception ex) 
        {
            Console.WriteLine("Exception in loading file. EX: {0}", ex.Message);
            return;
        }
    }
}
