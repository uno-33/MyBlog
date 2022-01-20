export class AuthModel {
    id: string = '';
    userName: string = '';
    dateOfCreation: string = '';
    roles: string[] = [];
    token: string = '';
    tokenExpiresIn: number = 0;
}