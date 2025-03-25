namespace Basket.API.Data
{
	public class CachedBasketRepository
		(IBasketRepository basketRepository , IDistributedCache distributedCache)
		: IBasketRepository
	{
		public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
		{
			await distributedCache.RemoveAsync(userName, cancellationToken);
			return await basketRepository.DeleteBasket(userName, cancellationToken);
		}
		public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
		{
			var cached = await distributedCache.GetStringAsync(userName, cancellationToken);
			if (!string.IsNullOrEmpty(cached))
			{
				  JsonSerializer.Deserialize<ShoppingCart>(cached);
			}

			var basket = await basketRepository.GetBasket(userName, cancellationToken);
			await distributedCache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);

			return basket;
		}
		public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
		{
			var basketValue = await basketRepository.StoreBasket(basket, cancellationToken);
			await distributedCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);

			return basketValue;
		}
	}
}