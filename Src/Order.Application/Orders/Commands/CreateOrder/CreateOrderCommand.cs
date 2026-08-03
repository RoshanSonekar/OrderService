using Order.Application.DTO;
using BuildingBlocks.CQRS;
using FluentValidation;

namespace Order.Application.Orders.Commands.CreateOrder
{
	public record CreateOrderResult(Guid Id);
	public record CreateOrderCommand (OrderDTO Order)
		:ICommand<CreateOrderResult>;

	public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
	{
		public CreateOrderCommandValidator()
		{
			RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required.");
			RuleFor(x => x.Order.CustomerId).NotEmpty().WithMessage("CustomerId is required.");
			RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("Order items is required.");
		}
	}

}
