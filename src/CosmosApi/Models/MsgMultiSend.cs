using System.Collections.Generic;
using CosmosApi.Serialization;
using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class MsgMultiSend : IMsg
    {
        [JsonProperty("inputs")]
        public IList<Input> Inputs { get; set; }
        
        [JsonProperty("outputs")]
        public IList<Output> Outputs { get; set; }

        public MsgMultiSend()
        {
        }

        public MsgMultiSend(IList<Input> inputs, IList<Output> outputs)
        {
            Inputs = inputs;
            Outputs = outputs;
        }
    }
}