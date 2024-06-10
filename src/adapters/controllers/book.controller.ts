import { Controller, Get, Post, Body, Param, Put, Delete } from '@nestjs/common';
import { BookService } from '../../application/services/book.service';
import { Book } from '../../domain/models/book.model';

@Controller('books')
