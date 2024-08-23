
import { defHttp } from '/@/utils/http/axios';
import {
  Product,
  CreateProduct,
  UpdateProduct,
  GetProductPagedRequest,
} from './model';

export const create = (input: CreateProduct) => {
  return defHttp.post<Product>({
    url: '/api/product/product',
    data: input,
  });
};

export const update = (id: string, input: UpdateProduct) => {
  return defHttp.put<Product>({
    url: `/api/product/product/${id}`,
    data: input,
  });
};

export const deleteById = (id: string) => {
  return defHttp.delete<void>({
    url: `/api/product/product/${id}`,
  });
};

export const getById = (id: string) => {
  return defHttp.get<Product>({
    url: `/api/product/product/${id}`,
  });
};

export const getList = (input: GetProductPagedRequest) => {
  return defHttp.get<PagedResultDto<Product>>({
    url: '/api/product/product',
    params: input,
  });
};
