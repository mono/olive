using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace ConsoleWCFSample
{
  [ServiceContract]
  public interface IServiceBase
  {
    [OperationContract(IsOneWay = true)]   
    void Say(string word);
  }

  [ServiceContract(CallbackContract = typeof(IServiceBase))]
  public interface IService : IServiceBase
  {
    [OperationContract]
    void Join();
  }

  class ServiceBase : IServiceBase
  {
    public ServiceBase() {}

    public virtual void Say(string word)
    {
      System.Console.WriteLine("hears {0}", word);
    }
  }

  [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
  class ServiceCallback : ServiceBase
  {
    public ServiceCallback() : base() { }
    public override void Say(string word)
    {
      System.Console.Write("Client callback ");
      base.Say(word);
    }
  }

  public class ServiceClient : DuplexClientBase<IService>, IService
  {
    public ServiceClient(InstanceContext callbackInstance) : base(callbackInstance) { }
    public void Say(string word) { base.Channel.Say(word); }
    public void Join() { base.Channel.Join(); }
  }

  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
  class Service : ServiceBase, IService
  {
    private List<IServiceBase> clients = new List<IServiceBase>();

    public Service() : base() { }

    public void Join()
    {
      IServiceBase client = OperationContext.Current.GetCallbackChannel<IServiceBase>();
      if (!clients.Contains(client)) clients.Add(client);
    }

    public virtual void NotifyOtherClients(string word)
    {
      IServiceBase client = OperationContext.Current != null ? OperationContext.Current.GetCallbackChannel<IServiceBase>() : null;
      foreach (IServiceBase c in clients) if (c != client) c.Say(word);
    }

    public override void Say(string word)
    {
      System.Console.Write("Server ");
      base.Say(word);
      NotifyOtherClients(word);
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      ServiceHost server = new ServiceHost(new Service());
      server.Open();
foreach (ChannelDispatcher cd in server.ChannelDispatchers)
foreach (var dop in cd.Endpoints [0].DispatchRuntime.Operations)
Console.WriteLine (dop.Action);

      Console.ReadLine();
    }
  }
}

