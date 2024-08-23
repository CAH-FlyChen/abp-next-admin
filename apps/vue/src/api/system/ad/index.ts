
import { defHttp } from '/@/utils/http/axios';
import {
  Ad,
  CreateAd,
  UpdateAd,
  GetAdPagedRequest,
} from './model';

export const create = (input: CreateAd) => {
  return defHttp.post<Ad>({
    url: '/api/system/ad',
    data: input,
  });
};

export const update = (id: string, input: UpdateAd) => {
  return defHttp.put<Ad>({
    url: `/api/system/ad/${id}`,
    data: input,
  });
};

export const deleteById = (id: string) => {
  return defHttp.delete<void>({
    url: `/api/system/ad/${id}`,
  });
};

export const getById = (id: string) => {
  return defHttp.get<Ad>({
    url: `/api/system/ad/${id}`,
  });
};

export const getList = (input: GetAdPagedRequest) => {
  return defHttp.get<PagedResultDto<Ad>>({
    url: '/api/system/ad',
    params: input,
  });
};
