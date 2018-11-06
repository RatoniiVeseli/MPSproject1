using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class RegisterHostMessage : MessageBase
{
    public string m_Name;
}

public class Network : NetworkManager
{
    RegisterHostMessage m_Message;
    public const short m_MessageType = MsgType.Highest + 1;

    public override void OnServerConnect(NetworkConnection connection)
    {
        //NetworkServer.SendToClient(connection.connectionId, m_MessageType, m_Message);
    }

    public override void OnClientConnect(NetworkConnection connection)
    {
        client.RegisterHandler(m_MessageType, ReceiveMessage);
    }

    void EditMessage(string myName)
    {
        m_Message = new RegisterHostMessage();
        m_Message.m_Name = myName;
    }
    
    public void ReceiveMessage(NetworkMessage networkMessage)
    {
        RegisterHostMessage hostMessage = networkMessage.ReadMessage<RegisterHostMessage>();
        string receivedName = hostMessage.m_Name;
    }
}