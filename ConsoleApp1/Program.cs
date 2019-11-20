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

    public interface IContravariance<in T>
    {
        void Do(T test);
    }

    public class Contravariance : IContravariance<Message>
    {
        public void Do(Message test)
        {
            Console.WriteLine(test.Content);
        }
    }

    public interface ICovariance<out T>
    {
        T Create(string msg);
    }

    public class Covariance : ICovariance<TitledMessage>
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

    public interface IX<out T>
    {
        T Do(T x, Action<T> d);
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Contravariance:
            // -----------
            // less derived type is used in the implementation generic type,
            // and less derived type is used ONLY as input values,
            // therefore can be assigned to derived type.
            IContravariance<Message> d = new Contravariance();
            IContravariance<TitledMessage> f = d;
            f.Do(new TitledMessage {Content = "Hello world"});

            // Covariance:
            // ----------
            // derived type is used in the implementation generic type,
            // and derived type is used ONLY as output values,
            // therefore can be assigned to less derived type.
            ICovariance<TitledMessage> a = new Covariance();
            ICovariance<Message> b = a;
            Message v = b.Create("Hello world");
            Console.WriteLine(v.Content);
        }
    }
}