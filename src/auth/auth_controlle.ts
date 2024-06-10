import { Controller, Request, Post, UseGuards } from '@nestjs/common';
import { AuthService } from './auth_service';
import { LocalAuthGuard } from './local-auth.guard'; // Necesitarás crear este guard
import { JwtAuthGuard } from './jwt-auth.guard'; // Necesitarás crear este guard

@Controller('auth')
export class AuthController {
  constructor(private readonly authService: AuthService) {}

  @UseGuards(LocalAuthGuard)
  @Post('login')
  async login(@Request() req) {
    return this.authService.login(req.user);
  }

  @UseGuards(JwtAuthGuard)
  @Post('profile')
  getProfile(@Request() req) {
    return req.user;
  }
}
