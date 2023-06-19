

using BuilderDesignPattern.Models;

VehicleBuilder builder;

Shop shop = new Shop();

builder = new ScooterBuilder();
shop.Construct(builder);
builder.Vehicle.Show();

builder = new MotorCycleBuilder();
shop.Construct(builder);
builder.Vehicle.Show();

builder = new CarBuilder();
shop.Construct(builder);
builder.Vehicle.Show();

