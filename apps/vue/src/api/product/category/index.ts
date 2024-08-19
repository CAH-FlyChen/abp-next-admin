
import { defHttp } from '/@/utils/http/axios';
import {
  Category,
  CreateCategory,
  UpdateCategory,
  GetCategoryPagedRequest,
} from './model';

export const create = (input: CreateCategory) => {
  return defHttp.post<Category>({
    url: '/api/product/category',
    data: input,
  });
};

export const update = (id: string, input: UpdateCategory) => {
  return defHttp.put<Category>({
    url: `/api/product/category/${id}`,
    data: input,
  });
};

export const deleteById = (id: string) => {
  return defHttp.delete<void>({
    url: `/api/product/category/${id}`,
  });
};

export const getById = (id: string) => {
  return defHttp.get<Category>({
    url: `/api/product/category/${id}`,
  });
};

export const getList = (input: GetCategoryPagedRequest) => {
  return defHttp.get<PagedResultDto<Category>>({
    url: '/api/product/category',
    params: input,
  });
};
