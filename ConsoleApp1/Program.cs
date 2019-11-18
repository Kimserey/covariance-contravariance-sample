using System;

namespace ConsoleApp1
{
    public class Message
    {
        public string Content { get; set; }
    }

    public class TitledMessage: Message
    {
        public string Title { get; set; }
    }

    public interface ICovariance<in T>
    {
        void Do(T test);
    }

    public class Covariance : ICovariance<Message>
    {
        public void Do(Message test)
        {
            Console.WriteLine(test.Content);
        }
    }

    public interface IContravariance<out T>
    {
        T Create(string msg);
    }

    public class Contravariance : IContravariance<TitledMessage>
    {
        public TitledMessage Create(string msg)
        {
            return new TitledMessage
            {
                Title = "My Title",
                Content = msg
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
// Covariance:
// -----------
// less derived type is used in the implementation generic type,
// and less derived type is used ONLY as input values,
// therefore can be assigned to derived type.
ICovariance<TitledMessage> test = new Covariance();
test.Do(new TitledMessage {Content = "Hello world"});

// Contravariance:
// derived type is used in the implementation generic type,
// and derived type is used ONLY as output values,
// therefore can be assigned to less derived type.
IContravariance<Message> contravariance = new Contravariance();
Message v = contravariance.Create("Hello world");
Console.WriteLine(v.Content);
        }
    }
}