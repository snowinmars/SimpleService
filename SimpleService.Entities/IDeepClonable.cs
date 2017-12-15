namespace SimpleService.Entities
{
	public interface IDeepClonable<T>
	{
		T DeepClone();
	}
}