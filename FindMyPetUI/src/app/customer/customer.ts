export class Customer
{

  constructor(
    public username: string = '',
    public password: string = '',
    public customerId: number = 0,
    public firstName: string = 'Test',
    public lastName: string = 'User',
    public email: string = '',
    public homeLongitude: number = 0,
    public homeLatitude: number = 0,
    public wanderingRadius: number = 0,
    public phoneNum: number = 0,
    public zipcode: number = 0
  ) {}

}