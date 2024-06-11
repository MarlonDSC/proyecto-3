import { Module } from '@nestjs/common';
import { MongooseModule } from '@nestjs/mongoose';
import { ConfigModule } from '@nestjs/config';
import { AuthorController } from './adapters/controllers/author.controller';
import { BookController } from './adapters/controllers/book.controller';
import { AuthorService } from './application/services/author.service';
import { BookService } from './application/services/book.service';
import { DatabaseModule } from './infrastructure/databases/mongoose.module';
import { RabbitMQModule } from '@golevelup/nestjs-rabbitmq';
import env from './infrastructure/databases/config/env';

@Module({
  imports: [
    ConfigModule.forRoot({
      isGlobal: true,
      load: [env],
    }),
    MongooseModule.forRootAsync({
      useFactory: () => ({
        uri: process.env.MONGO_URI,
      }),
    }),
    RabbitMQModule.forRoot(RabbitMQModule, {
      exchanges: [
        {
          name: 'exchange1',
          type: 'topic',
        },
      ],
      uri: process.env.RABBITMQ_URI,
      connectionInitOptions: { wait: false },
    }),
    DatabaseModule,
  ],
  controllers: [AuthorController, BookController],
  providers: [AuthorService, BookService],
})
export class AppModule {}
