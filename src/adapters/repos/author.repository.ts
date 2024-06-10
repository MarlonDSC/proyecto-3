import { Injectable } from '@nestjs/common';
import { InjectModel } from '@nestjs/mongoose';
import { Model } from 'mongoose';
import { AuthorRepository } from '../../domain/repos/author.repository.interface';
import { Author } from '../../domain/models/author.model';
import { Author as AuthorDocument } from '../../infrastructure/databases/schemas/author.schema';

@Injectable()
export class AuthorRepositoryImpl implements AuthorRepository {
  constructor(@InjectModel(AuthorDocument.name) private authorModel: Model<AuthorDocument>) {}

  async create(author: Author): Promise<Author> {
    const newAuthor = new this.authorModel(author);
    return newAuthor.save();
  }

  async findAll(): Promise<Author[]> {
    return this.authorModel.find().exec();
  }

  async findOne(id: string): Promise<Author> {
    return this.authorModel.findById(id).exec();
  }

  async update(id: string, author: Author): Promise<Author> {
    return this.authorModel.findByIdAndUpdate(id, author, { new: true }).exec();
  }

  async delete(id: string): Promise<Author> {
    return this.authorModel.findByIdAndDelete(id).exec();
  }
}
