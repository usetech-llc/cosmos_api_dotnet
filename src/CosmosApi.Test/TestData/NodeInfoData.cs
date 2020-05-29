using CosmosApi.Models;

namespace CosmosApi.Test.TestData
{
    public class NodeInfoData
    {
        public static NodeStatus NodeStatus = new NodeStatus()
        {
            NodeInfo = new NodeInfo()
            {
                ProtocolVersion = new ProtocolVersion()
                {
                    P2p = 7,
                    Block = 10,
                    App = 0
                },
                Id = "4bb4649d6cec92821f3d54e8c7d83fa6a9c6a4b0",
                ListenAddr = "tcp://0.0.0.0:26656",
                Network = "testing",
                Version = "0.32.9",
                Channels = "4020212223303800",
                Moniker = "testing",
                Other = new OtherVersionsInformation()
                {
                    TxIndex = "on",
                    RpcAddress = "tcp://0.0.0.0:26657"
                }
            },
            ApplicationVersion = new AplicationVersion()
            {
                Name = "gaia",
                ServerName = "gaiad",
                ClientName = "gaiacli",
                Version = "",
                Commit = "",
                BuildTags = "netgo,ledger",
                Go = "go version go1.14.2 linux/amd64"
            }
        }; 
    }
}