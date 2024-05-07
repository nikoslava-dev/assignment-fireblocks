using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.models;

namespace assignment.services
{
    public class FileService
    {
        public Task<string> ReadFile(string path) 
        {
            if (path == null || !File.Exists(path)) 
            {
                Console.WriteLine("No file path provided");
                return Task.FromResult(string.Empty);
            }

            try
            {
                return File.ReadAllTextAsync(path);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return Task.FromResult(string.Empty);
            }
        }

        public Dictionary<int, StateEntity>? ParseFileContent(string fileContent)
        {
            try
            {
                if(fileContent == null || fileContent == string.Empty)
                {
                    return null;
                }

                Dictionary<int, StateEntity> state = new Dictionary<int, StateEntity>();
                StateService stateService = StateService.GetInstance;

                string[] strArray = fileContent.Split(", ");
                for(int index = 0; index < strArray.Length; index++)
                {
                    StateEntity entity = stateService.ParseValue(strArray[index]);
                    if(entity == null)
                    {
                        continue;
                    }      

                    state.Add(index, entity);
                }

                return state;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occure in parsing file content. EX: {0}", ex.Message);
                return null;
            }
        }
    }
}