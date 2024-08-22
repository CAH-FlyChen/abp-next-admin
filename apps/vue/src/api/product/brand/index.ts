
import { defHttp } from '/@/utils/http/axios';
import {
  Brand,
  CreateBrand,
  UpdateBrand,
  GetBrandPagedRequest,
} from './model';

export const create = (input: CreateBrand) => {
  return defHttp.post<Brand>({
    url: '/api/product/brand',
    data: input,
  });
};

export const update = (id: string, input: UpdateBrand) => {
  return defHttp.put<Brand>({
    url: `/api/product/brand/${id}`,
    data: input,
  });
};

export const deleteById = (id: string) => {
  return defHttp.delete<void>({
    url: `/api/product/brand/${id}`,
  });
};

export const getById = (id: string) => {
  return defHttp.get<Brand>({
    url: `/api/product/brand/${id}`,
  });
};

export const getList = (input: GetBrandPagedRequest) => {
  return defHttp.get<PagedResultDto<Brand>>({
    url: '/api/product/brand',
    params: input,
  });
};
