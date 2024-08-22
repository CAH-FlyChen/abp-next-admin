
import { defHttp } from '/@/utils/http/axios';
import {
  Unit,
  CreateUnit,
  UpdateUnit,
  GetUnitPagedRequest,
} from './model';

export const create = (input: CreateUnit) => {
  return defHttp.post<Unit>({
    url: '/api/product/unit',
    data: input,
  });
};

export const update = (id: string, input: UpdateUnit) => {
  return defHttp.put<Unit>({
    url: `/api/product/unit/${id}`,
    data: input,
  });
};

export const deleteById = (id: string) => {
  return defHttp.delete<void>({
    url: `/api/product/unit/${id}`,
  });
};

export const getById = (id: string) => {
  return defHttp.get<Unit>({
    url: `/api/product/unit/${id}`,
  });
};

export const getList = (input: GetUnitPagedRequest) => {
  return defHttp.get<PagedResultDto<Unit>>({
    url: '/api/product/unit',
    params: input,
  });
};
