import request from '@/utils/http'


export const getDetail = (id) => {
  return request({
    url: '/api/product/product/'+id,
    params: {
    }
  })
}

export const getHotGoodsAPI = ({ id, type, limit = 3 }) => {
  return request({
    url: '/goods/hot',
    params: {
      id,
      type,
      limit
    }
  })
}