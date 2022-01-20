export class LoginResult {
  token: string;
  expiresIn: string;

  constructor(token: string, expiresIn: string) {
    this.token = token;
    this.expiresIn = expiresIn;  
  }
}