import { Injectable } from '@nestjs/common';
import { JwtService } from '@nestjs/jwt';
import { User } from './user.interface';


@Injectable()
export class AuthService {
  constructor(
    private readonly jwtService: JwtService
  ) {}

  async validateUser(username: string, pass: string): Promise<any> {
    // Aquí validarías el usuario contra tu base de datos
    const user: User = { userId: 1, username: 'marlon' }; // Ejemplo de usuario

    if (user && user.username === username) {
      const { password, ...result } = user; // 'password' es opcional en 'User'
      return result;
    }
    return null;
  }

  async login(user: any) {
    const payload = { username: user.username, sub: user.userId };
    return {
      access_token: this.jwtService.sign(payload),
    };
  }
}
