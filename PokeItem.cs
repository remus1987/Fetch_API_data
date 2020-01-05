using System;
using System.Collections.Generic;
using System.Text;

// Define pokemon Model
namespace Fetch_API_Data
{
    class PokeItem
    {
        public PokeItem(string name)
        {
            Name = name;
        }
        //Name property auto-implemented
        public string Name { get; set; }


    }
}
