using BuildingBlocks.CQRS;
using FluentValidation;
using Order.Application.DTO;

namespace Order.Application.Orders.Commands.UpdateOrder
{
	public record UpdateOrderResult(bool IsSuccess);
	public record UpdateOrderCommand (OrderDTO Order)
		:ICommand<UpdateOrderResult>
	{
	}

	public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
	{
		public UpdateOrderCommandValidator()
		{
			RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id is required.");
			RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required.");
			RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required.");
			RuleFor(x => x.Order.OrderItems).NotNull().WithMessage("Order items is required.");
		}
	}
}
