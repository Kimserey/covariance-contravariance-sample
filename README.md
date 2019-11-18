## Example showcasing usecases for Covariance and Contravariance

Covariance and contravariance allow implicit conversions generic types.

```c#
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
```
