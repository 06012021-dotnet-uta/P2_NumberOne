export class Customer
{

  constructor(
    public username: string,
    public password: string,
    public id: number,
    public firstName: string,
    public lastName: string,
    public email: string,
    public homeLongitude: number,
    public homeLatitude: number,
    public wanderingRadius: number,
    public phoneNum: number,
    public zipcode: number
  ) {}

}