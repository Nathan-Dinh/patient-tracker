using MaterialSkin.Controls;

namespace ClientTracker
{
    class IdGenerater
    {
        //Loops through Client Listbox collecting each files directory which will be stored in a string array
        private string[] ClientTextFileReader(MaterialListBox lstClient)
        {
            return Directory.GetFiles(Constants.folderDirectory).Select(filePath => filePath).ToArray();
        }

        //This function returns a list which containes any ID that is already being used
        private List<int> ClientTextFileWriter(string[] clientTextFileName)
        {
            return clientTextFileName.Select(fileName =>
            {
                var fileTextInformation = File.ReadAllText(fileName);
                string[] outerStringArray = fileTextInformation.Split('|');
                return int.Parse(outerStringArray[0]);
            }).ToList();
        }
        //This is the main code that generates the ID for the Clients Note
        public int IDGenerator(MaterialListBox lstClient)
        {
            List<int> clientIDList = ClientTextFileWriter(ClientTextFileReader(lstClient));
            return Enumerable.Range(0, 999)
                  .Except(clientIDList)
                  .OrderBy(x => Guid.NewGuid())
                  .FirstOrDefault();
        }
    }
}
