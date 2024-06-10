import { Module } from '@nestjs/common';
import { JwtModule } from '@nestjs/jwt';
import { PassportModule } from '@nestjs/passport';
import { AuthService } from './auth_service';
import { JwtStrategy } from './jwt_strategy';

@Module({
  imports: [
    PassportModule,
    JwtModule.register({
      secret: 'your-secret-key',  // Cambia esto por una clave secreta real
      signOptions: { expiresIn: '60s' },
    }),
  ],
  providers: [AuthService, JwtStrategy],
  exports: [AuthService],
})
export class AuthModule {}
