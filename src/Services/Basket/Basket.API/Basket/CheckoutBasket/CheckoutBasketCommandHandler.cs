﻿namespace Basket.API.Basket.CheckoutBasket;
public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto)
: ICommand<CheckoutBasketResult>;
public record CheckoutBasketResult(bool IsSuccess);
public class CheckoutBasketCommandHandler(IBasketRepository repository)
	: ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
	public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, 
												CancellationToken cancellationToken)
	{
		var basket = await repository.GetBasket(command.BasketCheckoutDto.UserName, 
										cancellationToken);
		if (basket == null)
		{
			return new CheckoutBasketResult(false);
		}

		await repository.DeleteBasket(command.BasketCheckoutDto.UserName, cancellationToken);

		return new CheckoutBasketResult(true);
	}
}